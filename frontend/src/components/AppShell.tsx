import Link from "next/link";


export default function AppShell({
    children
}: {
    children: React.ReactNode;
}){
    return (
        <div>
            <nav className="border-b p-4">
                <div className="flex gap-6">
                    <Link href="/dashboard">Dashboard</Link>
                    <Link href="/review">Weekly Review</Link>
                    <Link href="/trends">Trends</Link>
                    <Link href="/log">Log Food</Link>
                    <Link href="/profile">Profile</Link>
                    <Link href="/daily">Daily Nutrition</Link>
                    <Link href="/recommendations">Recommendations</Link>
                    <Link href="/nutrition-history">Nutrition History</Link>
                    <Link href="/history">Food History</Link>
                    <Link href="/settings">Settings</Link>
                </div>
            </nav>
            <main>{children}</main>
        </div>    );
}   