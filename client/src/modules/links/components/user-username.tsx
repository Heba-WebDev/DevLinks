import { Skeleton } from "@/components/ui";

export default function UserUsername({ username }: { username: string}) {
    return (
      <div className="relative h-2 w-20 pt-2 mx-auto flex justify-center">
        {!username && <Skeleton className="rounded-full w-20" />}
        {username && <p className="text-gray font-extralight text-sm">{username}</p>}
      </div>
    );
}