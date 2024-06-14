import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/issues/domain/entities/info_detail.dart';
import '../../../../core/error/exceptions.dart';
import '../../../../core/error/failures.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/repository/info_detail.dart';
import '../datasource/info_remote_datasource.dart';

class InfoRepositoryImpl implements InfoRepository {
  final InfoRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  InfoRepositoryImpl({
    required this.remoteDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, InfoDetail>> getInfoDetail(String id) async {
    if (await networkInfo.isConnected) {
      try {
        final infoDetail = await remoteDataSource.GetInfoDetail(id);
        return Right(infoDetail);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }

  @override
  Future<Either<Failure, InfoDetail>> getAllInfo(
      ) async {
    if (await networkInfo.isConnected) {
      try {
        final infoDetail = await remoteDataSource.GetAllInfoDetail();
        return Right(infoDetail);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }
}
