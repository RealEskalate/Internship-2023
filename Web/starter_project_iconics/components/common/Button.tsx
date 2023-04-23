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

  // optional icon preceding text
  endIcon?: JSX.Element

  // optional trailing icon
  startIcon?: JSX.Element
}

function Button({ label,
  className, startIcon, endIcon,
  ...props }: ButtonProps){
  return (
<<<<<<< HEAD
    <button {...props} className={clsx('flex justify-center items-center gap-x-2 px-4 py-2 m-2 text-white bg-primary rounded-md cursor-pointer', className)}>{startIcon && startIcon} {label} {endIcon && endIcon} </button>
=======
    <button {...props} className={clsx('flex justify-center items-center gap-x-2 px-4 py-2 m-2 text-white bg-[#264FAD] rounded-md cursor-pointer', className)}>{startIcon && startIcon} {label} {endIcon && endIcon} </button>
>>>>>>> af25d5c (add optional icon to button)
  )
}

export default Button