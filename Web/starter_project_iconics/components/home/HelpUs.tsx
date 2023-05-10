const HelpUs: React.FC = () => {
  return (
    <div className="bg-gradient-to-r from-primary to-lightPrimary">
      <div
        className="flex flex-col items-center justify-center gap-12 py-32"
        style={{
          backgroundImage: 'url("/img/home/help-us.png")',
          backgroundPosition: '50% 50%',
          backgroundRepeat: 'no-repeat',
        }}
      >
        <h3 className="capitalize text-3xl font-semibold text-white text-center">
          Help us sustain our mission!
        </h3>

        <button className="rounded-md py-2 px-12 capitalize bg-white text-xl font-semibold text-primary hover:bg-blue-600 hover:border-blue-600 hover:text-blue-100 duration-300">
          Support Us
        </button>
      </div>
    </div>
  )
}

export default HelpUs
