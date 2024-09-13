import AuthLayout from "@/layouts/auth-layout";
import { Link } from "react-router-dom";
import ForgotPasswordForm from "./Form";

export default function ForgotPassword() {
    return (
      <AuthLayout>
        <section className=" rounded-xl max-w-lg w-full bg-white p-4 md:p-10">
          <div className="flex flex-col gap-2 pb-8">
            <h1 className=" font-bold text-2xl md:text-3xl text-center">
              Forgot Password
            </h1>
            <p className=" text-gray font-light text-center">
              Enter the email address you used to create the account to receive
              instructions on how to reset your password
            </p>
          </div>
         <ForgotPasswordForm />
          <div className="py-6">
            <p className="text-center text-gray opacity-95">
              Remember your password?{" "}
              <Link to={"/login"} className="text-purple">
                Login
              </Link>
            </p>
          </div>
        </section>
      </AuthLayout>
    );
}