import Link from "next/link";

export default function HomePage() {

    return (
        <main className="min-h-screen">

            <section
                className="
                max-w-6xl
                mx-auto
                px-8
                py-24"
            >

                <div className="space-y-6">

                    <h1
                        className="
                        text-6xl
                        font-bold"
                    >
                        Pathya
                    </h1>

                    <h2
                        className="
                        text-2xl
                        text-muted-foreground"
                    >
                        Most nutrition apps track calories.

                        <br />

                        Pathya tracks what your body is missing.
                    </h2>

                    <div
                        className="
                        flex
                        gap-4"
                    >

                        <Link
                            href="/onboarding"
                            className="
                            border
                            rounded-lg
                            px-6
                            py-3"
                        >
                            Get Started
                        </Link>

                        <Link
                            href="/dashboard"
                            className="
                            border
                            rounded-lg
                            px-6
                            py-3"
                        >
                            Demo Dashboard
                        </Link>

                    </div>

                </div>

            </section>

            <section
                className="
                max-w-6xl
                mx-auto
                px-8
                py-16"
            >

                <h2
                    className="
                    text-3xl
                    font-bold
                    mb-8"
                >
                    Why Pathya?
                </h2>

                <div
                    className="
                    grid
                    md:grid-cols-3
                    gap-6"
                >

                    <div className="border rounded-lg p-6">
                        <h3 className="font-semibold mb-2">
                            Log Food
                        </h3>

                        <p>
                            Track meals using familiar Indian foods.
                        </p>
                    </div>

                    <div className="border rounded-lg p-6">
                        <h3 className="font-semibold mb-2">
                            Find Gaps
                        </h3>

                        <p>
                            See nutrient deficiencies instantly.
                        </p>
                    </div>

                    <div className="border rounded-lg p-6">
                        <h3 className="font-semibold mb-2">
                            Fix Them
                        </h3>

                        <p>
                            Get food recommendations that close those gaps.
                        </p>
                    </div>

                </div>

            </section>

            <section
                className="
                max-w-6xl
                mx-auto
                px-8
                py-16"
            >

                <h2
                    className="
                    text-3xl
                    font-bold
                    mb-8"
                >
                    Example Insight
                </h2>

                <div
                    className="
                    border
                    rounded-lg
                    p-6"
                >

                    <h3 className="font-semibold">
                        Iron Deficiency Risk
                    </h3>

                    <p className="mt-2">
                        Iron was below target on most days.
                    </p>

                    <p className="mt-2">
                        Add Rajma or Chickpeas to improve intake.
                    </p>

                </div>

            </section>

        </main>
    );
}