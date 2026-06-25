"use client";

import { getUserId } from "@/lib/user";
import { useRouter } from "next/navigation";
import { useEffect } from "react";

export default function RequireUser({
    children
}:{children: React.ReactNode}){
    const router = useRouter();
    useEffect(()=>{
        if(!getUserId()){
            router.push("/onboarding");
        }
    },[]);
    return <>{children}</>
}