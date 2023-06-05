import 'package:flutter_application_1/feature/issue/presentation%20/bloc/issue_bloc.dart';
import 'package:get_it/get_it.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';
import '../../feature/issue/domain/usecases/get_all_issue.dart';
import 'core/network/network_info.dart';
import 'feature/issue/data/dataSources/localdatasource.dart';
import 'feature/issue/data/dataSources/remotedatasource.dart';
import 'feature/issue/data/repository/Issue_repository.dart';
import 'feature/issue/domain/repositort/issue_repository.dart';
import 'feature/issue/domain/usecases/get_issue_by_Id.dart';

final sl = GetIt.instance;
Future<void> IssueInjectionInit() async {
  // Bloc
  sl.registerFactory(
    () => IssueBloc(
        issueRepository: sl(), getAllIssue: sl(),  getIssueById: sl()),
    );
   

    sl.registerLazySingleton(
      () => GetIssueById(repository: sl()),
    );

  // Repository
  sl.registerLazySingleton<IssueRepository>(
    () => IssueRepositoryImpl(
      localDataSource: sl(),
      remoteDataSource: sl(),
      networkInfo: sl(),
    ),
  );

  sl.registerLazySingleton<RemoteDataSource>(
    () => RemoteDataSourceImpl(client: sl(), authToken: ''),
  );

  sl.registerLazySingleton<Cache>(
    () => LocalDataSource(sharedPreferences: sl()));
  

  //core
  sl.registerLazySingleton<NetworkInfo>(
    () => NetworkInfoImpl(sl()),
  );

  //external
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());
}
