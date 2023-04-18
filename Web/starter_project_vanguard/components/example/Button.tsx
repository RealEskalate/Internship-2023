import clsx from 'clsx'

export interface ButtonProps extends React.ComponentProps<'button'> {
  /**
   * What shape it should be?
   */
  shape?: 'square' | 'circle'
  /**
   * Content of the button
   */
  label: string
  /**
   * Classes to modify the button
   */
  className?: string
  /**
   * Optional click handler
   */
  onClick?: () => void
 
}

/**
 *  Button component
 */
export const Button = ({
  label = 'Click Me',
  shape = 'circle',

  className,
  ...props
}: ButtonProps) => {
  return (
    <button
      {...props}
      className={clsx(
        shape === 'square' ? 'rounded-md' : 'rounded-full',
        `bg-blue-700 text-white px-2 py-1 h-[36px] w-[78px]`,
        className
      )}
    >
      {label}
    </button>
  )
}
