import { useAppSelector } from "@/hooks/store";
import UserPhoto from "./user-image";
import UserName from "./user-name";
import UserUsername from "./user-username";
import EmptyLinksSkeleton from "./empty-links-skeleton";
import { FaYoutube, FaGithub } from "react-icons/fa";

const platforms = [
    {
      "name": "YouTube",
      "icon": <FaYoutube />,
      "color": "#EE3939"
    },
    {
      "name": "GitHub",
      "icon": <FaGithub />,
      "color": "#1A1A1A"
    }
];

export default function Phone() {
    const user = useAppSelector((state) => state.user);
    const links = useAppSelector((state) => state.links);
    const emptyLinksCount = Math.max(0, 5 - (links?.length || 0));
    return (
      <>
        <div className="relative w-full pt-20 h-[550px]">
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
          <div className=" grid gap-14">
            <div className="flex flex-col gap-1">
              <UserPhoto image={user.image} />
              <UserName firstName={user.firstName} lastName={user.lastName} />
              <UserUsername username={user.username} />
            </div>

            <div className="flex flex-col gap-2 -mt-4 lg:mt-1">
              {links &&
                links.length > 0 &&
                links?.map((link, index) => {
                  const platform = platforms.filter(x => x.name.toLowerCase() === link.platformName.toLocaleLowerCase());
                  const color = platform[0].color;
                  return (
                    <div
                      key={index}
                      className={`relative bg-[${color}] text-white h-11 w-48 xl:w-52 mx-auto justify-center items-center rounded-md`}
                    >
                      <p className="rounded-small font-extralight h-full w-full flex gap-3 items-center px-4 text-center">
                        <span>{platform[0].icon}</span>{" "}
                        <span>{link.platformName}</span>
                      </p>
                    </div>
                  );
                })}
              <EmptyLinksSkeleton number={emptyLinksCount} />
            </div>
          </div>
        </div>
      </>
    );
}