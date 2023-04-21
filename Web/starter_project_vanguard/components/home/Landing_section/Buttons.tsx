
import Link from 'next/link'
export const Buttons = () => {
  return (
    <div className="flex w-full justify-start">
      {/* get started button goes here */}
      <div className="px-4 py-2 font-bold whitespace-nowrap mt-4 text-sm text-blue-500 border-2 border-blue-500 rounded-md">
        <Link href="/">Get Started</Link>
      </div>

      {/* support us button goes here */}
      <div className="px-4 sm:px-6 py-2 font-bold whitespace-nowrap mt-4 ml-4 text-sm text-white border-2 bg-button_color border-blue-500 rounded-md uppercase tracking-wide">
        <Link href="/">
          Support Us
          <svg
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke-width="1.5"
            stroke="currentColor"
            className="w-5 h-6 inline-block font-bold ml-2"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M4.5 12h15m0 0l-6.75-6.75M19.5 12l-6.75 6.75"
            />
          </svg>
        </Link>
      </div>
    </div>
  )
}
