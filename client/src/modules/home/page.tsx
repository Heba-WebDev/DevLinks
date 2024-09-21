import CoreValues from "./components/core-values";
import Hero from "./components/hero";
import NavBar from "./components/navbar"

export default function Home() {

  return (
    <main className="bg-white">
    <NavBar />
    <Hero />
    <CoreValues />
    </main>
  );
}
