"use client";

import AppShell from "@/components/AppShell";
import { clearUserId } from "@/lib/user";
import { useRouter } from "next/navigation";

export default function SettingsPage(){
    const router = useRouter();
    function logout(){
        clearUserId();
        router.push("/onboarding");
    }
    return (
        <AppShell>
            <main className="max-w-xl mx-auto p-8">
                <h1 className="text-3xl font-bold">Settings</h1>
                <button className="border rounded px-4 py-2 mt-4">
                    Logout
                </button>
            </main>
        </AppShell>
    )
}