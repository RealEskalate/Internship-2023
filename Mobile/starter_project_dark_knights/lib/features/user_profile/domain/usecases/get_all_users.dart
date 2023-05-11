import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';

class GetAllUsers implements UseCase<List<UserEntity>, NoParams> {
  final UserRepository userRepository;

  GetAllUsers(this.userRepository);
  @override
  Future<Either<Failure, List<UserEntity>>> call(NoParams noParams) async {
    return await userRepository.getAllUsers();
  }
}
