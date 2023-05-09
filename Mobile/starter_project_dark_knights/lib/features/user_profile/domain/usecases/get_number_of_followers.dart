import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';

class GetNumberOfFollowers implements UseCase<int, String> {
  final UserRepository userRepository;

  GetNumberOfFollowers(this.userRepository);

  @override
  Future<Either<Failure, int>> call(String id) async {
    return await userRepository.getNumberOfFollowers(id);
  }
}
