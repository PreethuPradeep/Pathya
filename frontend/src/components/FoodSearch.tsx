"use client";

import { useEffect, useState }
from "react";

import { Food }
from "@/types/Food";

import { searchFoods }
from "@/services/food.service";

interface Props {
    onSelect: (
        food: Food
    ) => void;
}

export default function FoodSearch({
    onSelect
}: Props) {

    const [query, setQuery] =
        useState("");

    const [foods, setFoods] =
        useState<Food[]>([]);

    useEffect(() => {

        async function search() {

            if (
                query.length < 2
            ) {
                setFoods([]);
                return;
            }

            const result =
                await searchFoods(
                    query
                );

            setFoods(result);
        }

        search();

    }, [query]);

    return (
        <div>

            <input
                value={query}
                onChange={e =>
                    setQuery(
                        e.target.value
                    )
                }
                placeholder="Search food..."
                className="
                    border
                    p-2
                    w-full"
            />

            <div
                className="
                    border
                    rounded"
            >
                {foods.map(food => (

                    <button
                        key={food.id}
                        onClick={() =>
                            onSelect(
                                food
                            )
                        }
                        className="
                            block
                            w-full
                            text-left
                            p-2
                            hover:bg-gray-100"
                    >
                        {food.name}
                    </button>

                ))}
            </div>

        </div>
    );
}