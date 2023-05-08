interface SuccessProps {
  year: Number
  rate: String
  average: Number
}

const SuccessCard: React.FC<SuccessProps> = ({ year, rate, average }) => {
  return (
    <div className="hidden lg:flex flex-col items-center justify-between rounded-lg w-1/5 h-60 py-5 shadow-lg bg-white my-7">
      <p className="text-primary-text font-semibold text-2xl py-2">
        {year.toString()}
      </p>
      <div className="flex flex-col items-center gap-2">
        <p className="text-primary-text font-semibold text-3xl">{rate}</p>
        <p className="text-secondary-text text-2xl">
          {average.toString()}% average
        </p>
      </div>
    </div>
  )
}

export default SuccessCard
