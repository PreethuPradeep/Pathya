import { FoodLogItem } from "@/types/FoodLogItem";

interface Props {
    items: FoodLogItem[];
    onDelete: (
        id: number
    ) => void;
}

export default function TodaysFoodLog({
    items,
    onDelete
}: Props) {
    return (
        <section>

            <h2 className="text-2xl font-semibold mb-4">
                Today&apos;s Foods
            </h2>

            <div className="space-y-2">

                {items.map(
                    (item, index) => (
                        <div
                            key={index}
                            className="border p-3 rounded"
                        >
                            <p className="font-medium">
                                {item.food}
                            </p>

                            <p className="text-sm text-muted-foreground">
                                {item.quantity} serving(s)
                            </p>

                            <p className="text-sm text-muted-foreground">
                                {item.weightInGrams}g
                            </p>

                            <button onClick={() => onDelete(item.id)}>
                                Delete
                            </button>
                        </div>
                    )
                )}

            </div>

        </section>
    );
}