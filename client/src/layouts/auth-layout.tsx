import { AuthLayoutProps } from "./types";

const AuthLayout: React.FC<AuthLayoutProps> = ({ children }) => {
  return (
    <>
      <section className="w-full flex flex-col gap-12 py-8 bg-white md:bg-grayLight h-screen md:h-auto md:items-center md:justify-center">
        <div className="px-4 md:px-10">
          <img src="/common/devlinks-logo.svg" alt="Devlinks Logo" />
        </div>
        {children}
      </section>
    </>
  );
};

export default AuthLayout;
