import clsx from 'clsx'

export interface ButtonProps extends React.ComponentProps<'button'> {

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

function Button({label,
className,
...props}: ButtonProps) {
  return (
    <button {...props} className={clsx( 'px-4 py-2 m-2 text-white bg-[#264FAD] rounded-md cursor-pointer', className)}>{label}  </button>
  )
}

export default Button