
export default function Mission() {
    return (
      <section className="flex flex-col-reverse md:flex-row-reverse py-12 px-2 md:px-6 max-w-screen-2xl mx-auto gap-4">
        <div className="w-full flex flex-col gap-1 lg:px-8 pt-6 ">
          <h2 className="text-purple text-center md:text-left font-bold text-lg">Our Mission & Vision</h2>
          <h3 className="text-2xl md:text-4xl text-center md:text-left md:w-[17ch] pb-4">Leading the Way, Redefining Connections</h3>
          <p className="text-gray md:max-w-[40ch] text-center md:text-left mx-auto md:mx-0">
            At DevLinks, we are dedicated to exceeding your expectations. We
            strive to understand your unique needs and challenges, providing
            tailored platform that drive real results and empower your success.
          </p>
        </div>
        <div className="relative w-full">
          <img
            src="/home/mission-desktop.svg"
            alt="developers talking"
            className="relative z-30 max-w-[80%] mx-auto hidden md:block"
          />
          <img
            src="/home/mission-mobile.svg"
            alt="developers talking"
            className="relative z-30 max-w-[90%] mx-auto block md:hidden"
          />
          <img
            src="/home/hero-dots-mobile.svg"
            alt=""
            className="absolute z-0 mx-auto -top-5 -left-2 md:left-4"
          />
          <img
            src="/home/hero-dots-mobile.svg"
            alt=""
            className="absolute z-0 mx-auto -bottom-5 -right-1 md:right-4"
          />
        </div>
      </section>
    );
}