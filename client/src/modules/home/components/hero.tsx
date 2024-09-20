
export default function Hero() {
    return (
      <section className="py-12 px-2 max-w-screen-2xl mx-auto">
        <div className="flex flex-col gap-2">
          <h1 className="text-center font-bold text-xl md:text-3xl">
            All Your Developer Social Links in{" "}
            <span className="text-purple">One Place</span>
          </h1>
          <p className=" text-gray text-center max-w-[40ch] md:max-w-[65ch] mx-auto">
            Easily share and showcase all your social profiles with a single
            link. Connect with other developers and keep your online presence
            organized and accessible, all in one convenient platform.
          </p>
        </div>
        <div className="py-12 relative">
          <img
            src="/home/hero-desktop.svg"
            alt="developers talking"
            className="relative z-30 max-w-[80%] mx-auto hidden md:block"
          />
          <img
            src="/home/hero-mobile.svg"
            alt="developers talking"
            className="relative z-30 max-w-[90%] mx-auto block md:hidden"
          />
          <img
            src="/home/hero-dots-desktop.svg"
            alt=""
            className="absolute z-0 mx-auto hidden md:block top-5 left-8 xl:left-[10%]"
          />
          <img
            src="/home/hero-dots-desktop.svg"
            alt=""
            className="absolute z-0 mx-auto hidden md:block bottom-5 right-8 xl:right-[10%]"
          />
          <img
            src="/home/hero-dots-mobile.svg"
            alt=""
            className="absolute z-0 mx-auto block md:hidden top-5 -left-2"
          />
          <img
            src="/home/hero-dots-mobile.svg"
            alt=""
            className="absolute z-0 mx-auto block md:hidden bottom-5 -right-1"
          />
        </div>
      </section>
    );
}