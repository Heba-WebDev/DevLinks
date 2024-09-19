import { useState } from "react";
import { Link } from "react-router-dom";
import { IoMenuOutline } from "react-icons/io5";
import { IoMdClose, IoMdHome, IoMdLogOut } from "react-icons/io";
import { FaUser, FaLink } from "react-icons/fa";
import { MdOutlinePowerSettingsNew } from "react-icons/md";
import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuItem,
} from "@/components/ui";
import { useAppDispatch, useAppSelector } from "@/hooks/store";
import { logout } from "@/store/user/user-slice";

export default function NavBar() {
    const [open, setOpen] = useState(false);
    const dispatch = useAppDispatch();
    const user = useAppSelector((state) => state.user);
    const logoutUser = () => {
      if (user.accessToken) {
        setOpen(false);
        dispatch(logout());
      }
    };
    return (
      <nav className="flex flex-row-reverse md:flex-row items-center justify-between bg-grayLight rounded-lg py-4 md:py-6 px-6">
        <div className="block md:hidden">
          <DropdownMenu open={open} onOpenChange={setOpen}>
            <DropdownMenuTrigger>
              {!open ? (
                <IoMenuOutline className="text-3xl hover:cursor-pointer" />
              ) : (
                <IoMdClose className="text-2xl hover:cursor-pointer" />
              )}
            </DropdownMenuTrigger>
            <DropdownMenuContent className="block md:hidden shadow-lg w-[90vw] mx-auto mr-6 mt-6 flex-col py-4">
              <DropdownMenuItem className="flex items-center gap-2 pb-4">
                <IoMdHome className=" text-gray text-base" />
                <Link to={"/"} className=" font-semibold text-gray">
                  Home
                </Link>
              </DropdownMenuItem>
              <DropdownMenuItem className="flex items-center gap-2 pb-4">
                {user.accessToken ? (
                  <FaUser className=" text-gray text-sm" />
                ) : (
                  <IoMdHome className=" text-gray text-sm" />
                )}
                <Link
                  to={user.accessToken ? "/profile" : "/login"}
                  className=" font-semibold text-gray"
                >
                  {user.accessToken ? "Profile" : "Log in"}
                </Link>
              </DropdownMenuItem>
              <DropdownMenuItem
                className={`${
                  user.accessToken ? "flex" : "hidden"
                } items-center gap-2 pb-4`}
              >
                <FaLink className=" text-gray text-base" />
                <Link to={"/links"} className=" font-semibold text-gray">
                  Links
                </Link>
              </DropdownMenuItem>
              <DropdownMenuItem
                className="flex items-center gap-2 pb-4"
                onClick={logoutUser}
              >
                {user.accessToken ? (
                  <IoMdLogOut className=" text-gray font-bold text-base" />
                ) : (
                  <MdOutlinePowerSettingsNew className=" text-gray text-sm" />
                )}
                <Link
                  to={user.accessToken ? "/" : "/signup"}
                  className=" font-semibold text-gray"
                >
                  {user.accessToken ? "Log out" : "Get Started"}
                </Link>
              </DropdownMenuItem>
            </DropdownMenuContent>
          </DropdownMenu>
        </div>
        <Link to={"/"} className="">
          <img src="/common/devlinks-logo.svg" alt="Devlinks Logo" />
        </Link>
        <div className="hidden md:flex items-center gap-4">
          <Link
            to={"/login"}
            className=" bg-white border border-purple text-gray px-6 py-2 rounded-md"
          >
            Log in
          </Link>
          <Link
            to={"/signup"}
            className="bg-purple text-white px-6 py-2 rounded-md"
          >
            Get Started
          </Link>
        </div>
      </nav>
    );
}
