import { Skeleton } from "@/components/ui";

export default function UserName({ firstName, lastName }: { firstName: string | null, lastName: string | null }) {
    return (
      <div className="relative h-4 w-32 pt-2 mx-auto flex justify-center">
        {!firstName && !lastName && <Skeleton className="rounded-full w-32" />}
        {firstName && lastName && <p className="flex flex-wrap text-sm">{firstName} {lastName}</p>}
      </div>
    );
}