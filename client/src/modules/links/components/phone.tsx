import { Skeleton } from "@/components/ui";

export default function Phone() {
    return (
      <>
        <div className="relative w-full h-full">
          <div className="absolute inset-0">
            <img
              src="/common/phone.svg"
              alt="user links and photo"
              className="object-contain w-full h-full"
            />
          </div>
          <div className="absolute left-3 xl:left-4 top-2 inset-0">
            <img
              src="/common/screen.svg"
              alt="user links and photo"
              className="object-contain w-[96%] h-[99%]"
            />
          </div>
          <div className="absolute inset-0 right-2 top-20 h-20 w-20 mx-auto flex justify-center">
            <Skeleton className="rounded-full w-20 " />
          </div>
          <div className="absolute inset-0 right-2 top-[34%] h-4 w-32 mx-auto flex justify-center">
            <Skeleton className="rounded-full w-32" />
          </div>

          <div className="absolute inset-0 right-2 top-[39%] h-2 w-20 mx-auto flex justify-center">
            <Skeleton className="rounded-full w-20" />
          </div>
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
        </div>
      </>
    );
}