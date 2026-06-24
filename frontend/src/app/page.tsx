"use client";

import { useEffect }
    from "react";

import { useRouter }
    from "next/navigation";

import {
    getUserId
}
from "@/lib/user";

export default function Home() {

    const router =
        useRouter();

    useEffect(() => {

        const userId =
            getUserId();

        if (userId) {

            router.replace(
                "/dashboard"
            );
        }
        else {

            router.replace(
                "/onboarding"
            );
        }

    }, [router]);

    return null;
}