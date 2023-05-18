import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';

class EditUserById extends UseCase<User, User> {
  final UserRepository? repository;
  EditUserById(this.repository);

  @override
  Future<Either<Failure, User>> call(User user) async {
    return await repository!.editUserById(user);
  }
}
