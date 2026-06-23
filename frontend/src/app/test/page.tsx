"use client";

import { useEffect } from "react";
import { getTrends } from "@/services/trend.service";

export default function Test() {

    useEffect(() => {
        getTrends()
            .then(console.log);
    }, []);

    return <div>Testing Trends</div>;
}