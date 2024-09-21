
export default function CoreValues() {
    return (
      <section className="py-12 px-2 md:px-6 max-w-screen-2xl mx-auto grid gap-4">
        <h2 className="text-2xl font-bold text-center">Our Core Values</h2>
        <div className="grid md:grid-cols-2 gap-4 py-5">
          <div className="bg-purpleLight p-4 rounded-md">
            <h3 className="text-purple font-semibold text-xl pb-3">
              Simplicity
            </h3>
            <p className=" max-w-[50ch] text-gray">
              We believe in keeping things simple. Our platform allows
              developers to easily manage and share their social profiles
              without any hassle.
            </p>
          </div>
          <div className="bg-purpleLight p-4 rounded-md">
            <h3 className="text-purple font-semibold text-xl pb-3">
              Accessibility
            </h3>
            <p className=" max-w-[50ch] text-gray">
              Connecting with others should be easy. We ensure that your social
              links are always available and easy to find, fostering a more
              connected community.
            </p>
          </div>
          <div className="bg-purpleLight p-4 rounded-md">
            <h3 className="text-purple font-semibold text-xl pb-3">
              Transparency
            </h3>
            <p className=" max-w-[50ch] text-gray">
              Our platform values transparency. You are in control of how and
              where your social profiles are displayed, ensuring trust in every
              interaction.
            </p>
          </div>
          <div className="bg-purpleLight p-4 rounded-md">
            <h3 className="text-purple font-semibold text-xl pb-3">
              Collaboration
            </h3>
            <p className=" max-w-[50ch] text-gray">
              We thrive on collaboration. Our platform fosters connections
              between developers, making it easier to share, discover, and grow
              together.
            </p>
          </div>
        </div>
      </section>
    );
}