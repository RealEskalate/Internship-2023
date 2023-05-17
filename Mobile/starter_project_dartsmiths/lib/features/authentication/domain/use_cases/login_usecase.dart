// import 'package:dartsmiths/core/usecase/usecase.dart';
// import 'package:dartsmiths/features/authentication/domain/entity/authentication_payload.dart';
// import 'package:dartsmiths/features/authentication/domain/repository/login_repository.dart';
// import 'package:dartz/dartz.dart';

// import '../../../../core/errors/failures.dart';

// class LoginUsecase
//     implements Usecase<UserAuthCredential, UserAuthCredentialParams> {
//   final AuthenticationRepository repository;
//   @override
//   Future<Either<Failure, UserAuthCredential>> call(
//       UserAuthCredentialParams params) async {
//     return await repository.login(username: params.username, password: params.password);
//   }

//   LoginUsecase(this.repository);
// }

// class UserAuthCredentialParams {
//   String username;
//   String password;
//   UserAuthCredentialParams({required this.username, required this.password});
// }
