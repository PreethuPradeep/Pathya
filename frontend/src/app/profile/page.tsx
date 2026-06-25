"use client";

import AppShell from "@/components/AppShell";
import { getUserId } from "@/lib/user";
import { getUser, updateUser } from "@/services/user.service";
import { User } from "@/types/User";
import { useEffect, useState } from "react";

export default function ProfilePage(){
    const [user,setUser] = useState<User|null>(null);
    const [message,setMessage] = useState("");

    useEffect(() =>{
        async function load(){
            const data = await getUser(Number(getUserId()));
            setUser(data);
            }
            
        load();
    }, []);


    async function save() {
        if (!user) return;
        await updateUser(user.id,user);
        setMessage("Profile updated!");
    }

    if (!user){
        return (
            <p>Loading...</p>
        )
    }

    return (
        <AppShell>
            <main className="max-w-xl mx-auto p-8 space-y-4">
                <h1 className="text-3xl font-bold">Profile</h1>
                <div className="space-y-2">
                    <label className="font-medium">Weight (kg)</label>
                    <input type="number" value={user.weightKg} onChange={e => setUser({
                    ...user,weightKg: Number(e.target.value)
                })} className="w-full border rounded p-2"/>
                </div>
                <div className="space-y-2">
                    <label className="font-medium">Height (Cm)</label>
                    <input type="number" value={user.heightCm} onChange={e => setUser({
                    ...user,heightCm: Number(e.target.value)
                })} className="w-full border rounded p-2"/>
                </div>
                <div className="space-y-2">
                    <label className="font-medium">Gender</label>
                    <select value={user.gender} onChange={e => setUser({
                    ...user,gender: e.target.value
                })} className="w-full border rounded p-2">
                    <option>Female</option>
                    <option>Male</option>
                    </select>
                </div>
                <div className="space-y-2">
                    <label className="font-medium">Activity Level</label>
                    <select value={user.activityLevel} onChange={e => setUser({
                    ...user,activityLevel: e.target.value
                })} className="w-full border rounded p-2">
                    <option>Sedentary</option>
                    <option>Moderately Active</option>
                    <option>Active</option>
                    </select>
                </div>
                <button onClick={save} className="px-4 py-2 rounded border">Save Profile</button>
                {
                    message &&
                    <p>{message}</p>
                }
                
            </main>
        </AppShell>
    )
}
