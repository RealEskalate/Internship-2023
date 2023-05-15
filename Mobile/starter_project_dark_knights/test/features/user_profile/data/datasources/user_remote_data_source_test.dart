import 'package:dark_knights/features/user_profile/data/datasources/user_remote_data_source.dart';
import 'package:http/http.dart' as http;
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';
class MockhttpClient extends Mock implements http.Client{}


void main() {
  UserRemoteDataSourceImpl dataSource;
  MockhttpClient mockHttpClient;

 
   setUp(() {
  mockHttpClient = MockhttpClient();
      dataSource = UserRemoteDataSourceImpl(client:mockHttpClient);
  });
}