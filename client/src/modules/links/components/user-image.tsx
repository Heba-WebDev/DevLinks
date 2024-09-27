import { Skeleton } from "@/components/ui";

export default function UserPhoto({ image }: {image: string | null}) {
    return (
      <div className="relative h-20 w-20 mx-auto flex justify-center">
        {!image && <Skeleton className="rounded-full w-20 " />}
      </div>
    );
}
