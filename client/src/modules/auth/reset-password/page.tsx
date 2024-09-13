import AuthLayout from "@/layouts/auth-layout";
import ResetPasswordForm from "./Form";

export default function ResetPassword() {
  return (
    <AuthLayout>
      <section className=" rounded-xl max-w-lg w-full bg-white p-4 md:p-10">
        <div className="flex flex-col gap-2 pb-8">
          <h1 className=" font-bold text-2xl md:text-3xl text-center">
            Reset Password
          </h1>
          <p className=" text-gray font-light text-center">
            Your password must be at least 8 characters long
          </p>
        </div>
        <ResetPasswordForm />
      </section>
    </AuthLayout>
  );
}
