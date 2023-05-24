import Search from "@/components/Search";
export default function Home() {
  return (
    <main className="p-2">
      <Search />
      {/* List of doctors is shown from seach component as search with no keyword return all the doctors */}
    </main>
  );
}
