import successes from '@/data/home/success-rate'
import SuccessCard from './SuccessCard'

const SuccessRate = () => {
  return (
    <div className="flex flex-col items-center justify-between p-16 gap-8">
      <h2 className="text-5xl font-semibold max-w-[55vw] text-center capitalize leading-normal">
        Google SWE Interviews Acceptance Rate Comparison
      </h2>

      <div className="flex felx-row px-7 gap-5 items-center bg-secondary rounded-lg max-w-px-1560 h-75 overflow-auto">
        <p className="text-secondary-text text-center lg:text-start text-2xl my-12 w-full lg:w-1/5">
          A2SV students are{' '}
          <span className="font-semibold text-primary-text">35</span> times more
          likely to pass{' '}
          <span className="font-semibold text-primary-text">
            Google SWE interviews
          </span>{' '}
          than average candidates.
        </p>
        {successes.map((success) => (
          <SuccessCard
            key={success.year}
            year={success.year}
            rate={success.rate}
            average={success.average}
          />
        ))}
      </div>
    </div>
  )
}

export default SuccessRate
