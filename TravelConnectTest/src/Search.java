import java.util.regex.Pattern;
import java.util.concurrent.TimeUnit;
import org.junit.*;
import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;
import org.openqa.selenium.*;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.Select;

public class Search {
  private WebDriver driver;
  private String baseUrl;
  private boolean acceptNextAlert = true;
  private StringBuffer verificationErrors = new StringBuffer();

  @Before
  public void setUp() throws Exception {
	  String path = "C:/Users/BlueBongo/Downloads/chromedriver.exe";
	  System.setProperty("webdriver.chrome.driver", path);
    driver = new ChromeDriver();
    baseUrl = "https://travelconnect.ddns.net/";
    driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
  }

  @Test
  public void testSearchFromOmaha() throws Exception {
    driver.get("http://travelconnect.ddns.net/Trip");
    driver.findElement(By.linkText("Search")).click();
    driver.findElement(By.id("DepartureCity")).click();
    driver.findElement(By.id("DepartureCity")).clear();
    driver.findElement(By.id("DepartureCity")).sendKeys("Omaha");
    Thread.sleep(2000);
    driver.findElement(By.id("DepartureCity")).sendKeys(Keys.ENTER);
    Thread.sleep(2000);
    driver.findElement(By.linkText("Search")).click();
    driver.findElement(By.id("DestinationCity")).click();
    driver.findElement(By.id("DestinationCity")).clear();
    driver.findElement(By.id("DestinationCity")).sendKeys("Las Vegas");
    Thread.sleep(2000);
    driver.findElement(By.id("DepartureCity")).sendKeys(Keys.ENTER);
    Thread.sleep(2000);
driver.findElement(By.linkText("Search")).click();
    driver.findElement(By.id("MaxCost")).click();
    driver.findElement(By.id("MaxCost")).clear();
    driver.findElement(By.id("MaxCost")).sendKeys("1000.00");
    Thread.sleep(2000);
    driver.findElement(By.id("DepartureCity")).sendKeys(Keys.ENTER);
    Thread.sleep(2000);
  }

  @After
  public void tearDown() throws Exception {
    driver.quit();
    String verificationErrorString = verificationErrors.toString();
    if (!"".equals(verificationErrorString)) {
      fail(verificationErrorString);
    }
  }

  private boolean isElementPresent(By by) {
    try {
      driver.findElement(by);
      return true;
    } catch (NoSuchElementException e) {
      return false;
    }
  }

  private boolean isAlertPresent() {
    try {
      driver.switchTo().alert();
      return true;
    } catch (NoAlertPresentException e) {
      return false;
    }
  }

  private String closeAlertAndGetItsText() {
    try {
      Alert alert = driver.switchTo().alert();
      String alertText = alert.getText();
      if (acceptNextAlert) {
        alert.accept();
      } else {
        alert.dismiss();
      }
      return alertText;
    } finally {
      acceptNextAlert = true;
    }
  }
}
