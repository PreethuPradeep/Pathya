"use client";

import { setUserId } from "@/lib/user";
import { createUser } from "@/services/user.service";
import { useRouter } from "next/navigation";
import { useState } from "react";

export default function OnboardingPage() {
    const router = useRouter();
    const [dateOfBirth, setDateOfBirth] = useState("");
    const [gender, setGender] = useState("Female");
    const [isPregnant, setIsPregnant] = useState(false);
    const [isBreastfeeding, setIsBreastfeeding] = useState(false);
    const [heightCm, setHeightCm] = useState("");
    const [weightKg, setWeightKg] = useState("");
    const [activityLevel, setActivityLevel] = useState("Sedentary");
    const [loading, setLoading] = useState(false);

    async function handleSubmit(){
        try{
            setLoading(true);
            const result = await createUser({
                dateOfBirth,
                gender,
                isPregnant,
                isBreastfeeding,
                heightCm: Number(heightCm),
                weightKg: Number(weightKg),
                activityLevel
            });
            setUserId(result.userId);
            router.push("/dashboard");
        } catch (error) {
            console.error("Error creating user:", error);
            alert("Failed to create profile.");
        } finally {
            setLoading(false);
        }
    }
    return (
        <main className="max-w-xl mx-auto p-8 space-y-6">
            <h1 className="text-4xl font-bold">Welcome to Pathya</h1>
            <p className="text-muted-foreground"> Tell us a little about yourself.</p>
            <input type="date" value={dateOfBirth} onChange={(e) => setDateOfBirth(e.target.value)} placeholder="Date of Birth"
            className="border p-2 w-full"/>
            <select value={gender} onChange={(e) => setGender(e.target.value)} className="border p-2 w-full">
                <option>Female</option>
                <option>Male</option>
                <option>Other</option>
            </select>
            <input type="number" value={heightCm} onChange={(e) => setHeightCm(e.target.value)} placeholder="Height (cm)" className="border p-2 w-full"/>
            <input type="number" value={weightKg} onChange={(e) => setWeightKg(e.target.value)} placeholder="Weight (kg)" className="border p-2 w-full"/>
            <select value={activityLevel} onChange={(e) => setActivityLevel(e.target.value)} className="border p-2 w-full">
                <option>Sedentary</option>
                <option>Moderately Active</option>
                <option>Very Active</option>
            </select>
            {gender === "Female" && (
                <>
                    <label className="flex gap-2">
                        <input
                            type="checkbox"
                            checked={isPregnant}
                            onChange={(e) => setIsPregnant(e.target.checked)}
                        />
                        I am pregnant
                    </label>
                    <label className="flex gap-2">
                        <input
                            type="checkbox"
                            checked={isBreastfeeding}
                            onChange={(e) => setIsBreastfeeding(e.target.checked)}
                        />
                        I am breastfeeding
                    </label>
                </>
            )}
            <button onClick={handleSubmit} disabled={loading} className="border px-4 py-2">
                {loading ? "Creating Profile..." : "Continue"}
            </button>
        </main>
    );
}