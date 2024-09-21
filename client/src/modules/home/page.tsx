import CoreValues from "./components/core-values";
import Hero from "./components/hero";
import Mission from "./components/mission";
import NavBar from "./components/navbar"

export default function Home() {

  return (
    <main className="bg-white">
    <NavBar />
    <Hero />
    <CoreValues />
    <Mission />
    </main>
  );
}
