abstract class FormSubmittionStatus {
  const FormSubmittionStatus();
}

class InititalStatus extends FormSubmittionStatus {
  const InititalStatus();
}

class SubmittingStatus extends FormSubmittionStatus {
  const SubmittingStatus();
}

class SuccessStatus extends FormSubmittionStatus {
  const SuccessStatus();
}

class FailureStatus extends FormSubmittionStatus {
  const FailureStatus();
}
