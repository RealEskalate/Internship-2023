import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';

class DeleteUserById extends UseCase<void, String> {
  final UserRepository? repository;
  DeleteUserById(this.repository);

  @override
  Future<Either<Failure, void>> call(String id) async {
    return await repository!.deleteUserById(id);
  }
}
