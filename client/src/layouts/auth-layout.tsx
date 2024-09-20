import { Link } from "react-router-dom";
import { LayoutProps } from "./types";

const AuthLayout: React.FC<LayoutProps> = ({ children }) => {
  return (
    <>
      <section className="w-full flex flex-col gap-12 py-8 bg-white md:bg-grayLight h-screen md:h-auto md:items-center md:justify-center">
        <Link to={('/')} className="px-4 md:px-10">
          <img src="/common/devlinks-logo.svg" alt="Devlinks Logo" />
        </Link>
        {children}
      </section>
    </>
  );
};

export default AuthLayout;
