import React from "react";
import { useLocation, Link } from "react-router-dom";
import { LayoutProps } from "./types";
import { FaLink, FaRegUserCircle, FaEye } from "react-icons/fa";

const AppLayout: React.FC<LayoutProps> = ({ children }) => {
  const location = useLocation();
  return (
    <>
      <section className="w-full flex flex-col gap-12 py-8 h-screen">
        <nav className="grid grid-cols-3 items-center justify-between bg-white md:mx-6 rounded-lg p-4">
          <Link to={"/"} className="">
            <img
              src="/common/devlinks-logo.svg"
              alt="Devlinks Logo"
              className="hidden md:block"
            />
            <img
              src="/common/logo-icon-only.svg"
              alt="Devlinks Logo"
              className="block md:hidden"
            />
          </Link>
          <div className="flex gap-2 justify-between">
            <Link
              to={"/links"}
              className={`flex items-center gap-2 font-medium text-lg ${
                location.pathname === "/links"
                  ? "text-purple bg-purpleLight px-5 lg:px-7 py-3 rounded-lg"
                  : "text-gray"
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
                  : "text-gray"
              }`}
            >
              <FaRegUserCircle className=" text-2xl" />
              <p className="hidden md:block">Profile</p>
            </Link>
          </div>
          <Link
            to={"/preview"}
            className="flex gap-1 items-center justify-end text-purple"
          >
            <div className="text-xl border border-purple px-5 py-2 rounded-lg font-semibold block md:hidden">
              <FaEye className="" />
            </div>

            <p className="hidden md:block border border-purple px-7 py-3 rounded-lg font-semibold">
              Preview
            </p>
          </Link>
        </nav>
        {children}
      </section>
    </>
  );
};

export default AppLayout;
