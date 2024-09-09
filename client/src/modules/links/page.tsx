import AppLayout from "@/layouts/app-layout";
import LinksForm from "./components/form";
import Phone from "./components/phone";

export default function Links() {
    return (
      <AppLayout>
        <main className="h-screen lg:grid lg:grid-cols-3 lg:gap-6 mx-4 md:mx-6">
          <section className="hidden lg:block bg-white rounded-lg p-6 md:p-10 col-span-1">
            <Phone />
          </section>
          <section className="bg-white rounded-lg p-6 md:p-10 col-span-2">
            <div>
              <h1 className=" font-bold text-2xl md:text-3xl pb-1">
                Customize your links
              </h1>
              <p className="font-light text-gray text-base pb-10">
                Add/edit/remove links below and then share all your profiles
                with the world!
              </p>
            </div>
            <LinksForm />
          </section>
        </main>
      </AppLayout>
    );
}