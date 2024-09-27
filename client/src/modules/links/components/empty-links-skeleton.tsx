import { Skeleton } from "@/components/ui";

export default function EmptyLinksSkeleton({ number }: { number: number }) {
    return (
      <>
        {Array.from({ length: number }).map((_, index) => (
          <div
            key={index}
            className="h-11 w-48 xl:w-52 mx-auto flex justify-center"
          >
            <Skeleton className="rounded-small w-48 xl:w-52" />
          </div>
        ))}
      </>
    );
}