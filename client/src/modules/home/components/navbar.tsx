import { useState } from "react";
import { Link } from "react-router-dom";
import { IoMenuOutline } from "react-icons/io5";
import { IoMdClose, IoMdHome, IoMdLogOut } from "react-icons/io";
import { FaUser, FaLink, FaRegUserCircle } from "react-icons/fa";
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
        <div className={`hidden ${user.accessToken ? "md:flex" : "md:hidden"} gap-8 justify-between`}>
          <Link
            to={"/links"}
            className={`flex items-center gap-2 font-medium text-lg ${
              location.pathname === "/links"
                ? "text-purple bg-purpleLight px-5 lg:px-7 py-3 rounded-lg"
                : "text-gray px-5 lg:px-7 py-3 hover:text-purple"
            }`}
          >
            <FaLink className=" text-2xl" />
            <p className="hidden md:block">Links</p>
          </Link>
          <Link
            to={"/profile"}
            className={`flex items-center gap-2 font-medium text-lg ${
              location.pathname === "/profile"
                ? "text-purple bg-purpleLight px-5 lg:px-7 py-3 rounded-lg"
                : "text-gray px-5 lg:px-7 py-3 hover:text-purple"
            }`}
          >
            <FaRegUserCircle className=" text-2xl" />
            <p className="hidden md:block">Profile</p>
          </Link>
        </div>
        <div className="hidden md:flex items-center gap-4">
          <Link
            to={user.accessToken ? "/" : "/login"}
            onClick={() => {
              if (user.accessToken) logoutUser();
            }}
            className=" bg-white border border-purple text-gray px-6 py-2 rounded-md hover:bg-purpleLight hover:text-purple hover:border-transparent"
          >
            {user.accessToken ? "Log out" : "Log in"}
          </Link>
          <Link
            to={"/signup"}
            className={`bg-purple hover:bg-white border hover:border-purple hover:text-purple text-white px-6 py-2 rounded-md ${
              user.accessToken ? "hidden" : "block"
            }`}
          >
            Get Started
          </Link>
        </div>
      </nav>
    );
}
