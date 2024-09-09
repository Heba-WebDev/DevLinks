import AppLayout from "@/layouts/app-layout"
import Phone from "../links/components/phone";
import ProfileForm from "./components/form";

export default function Profile() {
    return (
      <AppLayout>
        <main className="h-screen lg:grid lg:grid-cols-3 lg:gap-6 mx-4 md:mx-6">
          <section className="hidden lg:block bg-white rounded-lg p-6 md:p-10 col-span-1">
            <Phone />
          </section>
          <section className="bg-white rounded-lg p-6 md:p-10 col-span-2">
            <div>
              <h1 className=" font-bold text-2xl md:text-3xl pb-1">
                Profile Details
              </h1>
              <p className="font-light text-gray text-base pb-10">
                Add your details to create a personal touch to you profile.
              </p>
            </div>
            <ProfileForm />
          </section>
        </main>
      </AppLayout>
    );
}