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
                </div>
            </nav>
            <main>{children}</main>
        </div>    );
}   