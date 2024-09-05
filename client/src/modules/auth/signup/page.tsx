import { Link } from "react-router-dom";
import AuthLayout from "@/layouts/auth-layout";
import RegisterForm from "./Form";

const Register = () => {
    return (
      <AuthLayout>
        <section className=" rounded-xl max-w-lg w-full bg-white p-4 md:p-10">
          <div className="flex flex-col gap-2 pb-8">
            <h1 className=" font-bold text-2xl md:text-3xl">Create account</h1>
            <p className=" text-gray font-light">
              Let's get you started sharing your links!
            </p>
          </div>
          <RegisterForm />
          <div className="py-6">
            <p className="text-center text-gray opacity-95">
              Already have an account? <Link to={'/login'} className="text-purple">Login</Link>
            </p>
          </div>
        </section>
      </AuthLayout>
    );
}

export default Register;