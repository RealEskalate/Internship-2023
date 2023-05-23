import 'package:flutter/material.dart';
import 'package:mobile_assessement/presentation/screen/detail.dart';

class HomePage extends StatelessWidget {
  TextEditingController searchController = TextEditingController();

  void searchButtonPressed(BuildContext context) {
    String searchTerm = searchController.text;
    // Perform the search logic or navigate to a new screen with search results

    // Navigate to the Detail() page
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => Detail(query: searchTerm),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    final screenSize = MediaQuery.of(context).size;
    final searchBoxWidth = screenSize.width * 0.707;
    final searchBoxHeight = screenSize.height * 0.059;
    final buttonWidth = screenSize.width * 0.180;
    final buttonHeight = screenSize.height * 0.056;

    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.transparent,
        elevation: 0,
        title: Text('Home Page'),
      ),
      body: Container(
        color: Color(0xFFF5F4FF),
        padding: EdgeInsets.all(20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Align(
              alignment: Alignment.center,
              child: Text(
                'Choose City',
                style: TextStyle(
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            SizedBox(height: 10),
            Row(
              children: [
                Container(
                  width: searchBoxWidth,
                  height: searchBoxHeight,
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    color: Colors.white,
                  ),
                  child: TextField(
                    controller: searchController,
                    decoration: InputDecoration(
                      hintText: 'Search a new city',
                      prefixIcon: Icon(Icons.search),
                      border: InputBorder.none,
                    ),
                  ),
                ),
                SizedBox(width: 5),
                Container(
                  width: buttonWidth,
                  height: buttonHeight,
                  child: ElevatedButton(
                    onPressed: () => searchButtonPressed(context),
                    style: ElevatedButton.styleFrom(
                      primary: Color(0xFFFFBA25),
                    ),
                    child: Text(
                      'Search',
                      style: TextStyle(
                        fontSize: 10,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                ),
              ],
            ),
            SizedBox(height: 10), // Add a SizedBox for spacing
            Text(
              'My fav City',
              style: TextStyle(
                fontSize: 16,
                fontWeight: FontWeight.bold,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
