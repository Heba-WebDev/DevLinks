import { Skeleton } from "@/components/ui";

export default function EmptyLinksSkeleton() {
    return (
      <>
        <div className="absolute inset-0 right-0 top-[50%] h-11 w-48 xl:w-52 mx-auto flex justify-center">
          <Skeleton className="rounded-small w-48  xl:w-52" />
        </div>

        <div className="absolute inset-0 right-0 top-[60%] h-11 w-48 xl:w-52 mx-auto flex justify-center">
          <Skeleton className="rounded-small w-48 xl:w-52" />
        </div>
        <div className="absolute inset-0 right-0 top-[70%] h-11 w-48 xl:w-52 mx-auto flex justify-center">
          <Skeleton className="rounded-small w-48 xl:w-52" />
        </div>
        <div className="absolute inset-0 right-0 top-[80%] h-11 w-48 xl:w-52 mx-auto flex justify-center">
          <Skeleton className="rounded-small w-48 xl:w-52" />
        </div>
      </>
    );
}