import Hero from "./components/hero";
import NavBar from "./components/navbar"

export default function Home() {

  return (
    <main className="bg-white h-screen">
    <NavBar />
    <Hero />
    </main>
  );
}
