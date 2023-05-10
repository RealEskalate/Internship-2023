import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';

class GetFollowing implements UseCase<List<UserEntity>, String> {
  final UserRepository userRepository;

  GetFollowing(this.userRepository);
  @override
  Future<Either<Failure, List<UserEntity>>> call(String userId) async {
    return await userRepository.getFollowing(userId);
  }
}
