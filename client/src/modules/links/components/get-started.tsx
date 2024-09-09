

export default function LetsGetStarted() {
    return (
      <div className="bg-grayLight grid gap-6 md:gap-10 border p-5 mb-10">
        <div className=" mx-auto pt-10">
          <img
            src="/links/get-started.svg"
            alt=""
            className="hidden md:block"
          />
          <img
            src="/links/get-started-mobile.svg"
            alt=""
            className="block md:hidden"
          />
        </div>
        <div className="grid gap-6 pb-10 text-center">
          <h2 className="font-bold text-2xl md:text-3xl">
            Let's get you started
          </h2>
          <p className="text-gray md:w-[45ch] md:mx-auto">
            Use the “Add new link” button to get started. Once you have more
            than one link, you can reorder and edit them. We’re here to help you
            share your profiles with everyone!
          </p>
        </div>
      </div>
    );
}