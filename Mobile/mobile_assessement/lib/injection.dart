import 'package:get_it/get_it.dart';
import "package:http/http.dart" as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:mobile_assessement/features/issues/domain/usecases/getallinfo.dart';
import 'package:mobile_assessement/features/issues/domain/usecases/info.dart';
import 'package:mobile_assessement/features/issues/presentation/bloc/issues_bloc.dart';

import 'core/network/network_info.dart';
import 'features/issues/data/datasource/info_remote_datasource.dart';
import 'features/issues/data/repository/info_repo.dart';
import 'features/issues/domain/repository/info_detail.dart';

final sl = GetIt.instance;

Future<void> init() async {
  sl.registerFactory(() => IssueBloc(GetAllInfoDetail(sl()), GetInfoDetail(sl())));

  // Use cases
  sl.registerLazySingleton(() => GetInfoDetail(sl()));
  sl.registerLazySingleton(() => GetAllInfoDetail(sl()));

  // Repository
  sl.registerLazySingleton<InfoRepository>(() => InfoRepositoryImpl(
      remoteDataSource: sl(), networkInfo: sl()));
  // Data sources
  sl.registerLazySingleton<InfoRemoteDataSource>(
    () => InfoRemoteDataSourceImpl(client: sl()),
  );
  

  // Core
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

  // External
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());
}
