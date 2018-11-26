import java.util.regex.Pattern;
import java.util.concurrent.TimeUnit;
import org.junit.*;
import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;
import org.openqa.selenium.*;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.Select;

public class CreateTrip {
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
  public void testCreateTrip() throws Exception {
    driver.get("http://travelconnect.ddns.net/Trip");
    driver.findElement(By.linkText("Login")).click();
    driver.findElement(By.id("Input_Email")).click();
    driver.findElement(By.id("Input_Email")).clear();
    driver.findElement(By.id("Input_Email")).sendKeys("asdf@asdf.edu");
    driver.findElement(By.id("Input_Password")).clear();
    driver.findElement(By.id("Input_Password")).sendKeys("3ed#ED");
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Password'])[1]/following::button[1]")).click();
    Thread.sleep(1000);
    driver.findElement(By.linkText("Create Trip")).click();
    Thread.sleep(1000);
    driver.findElement(By.id("DestinationCity")).click();
    driver.findElement(By.id("DestinationCity")).clear();
    driver.findElement(By.id("DestinationCity")).sendKeys("Maine");
    Thread.sleep(1000);
    driver.findElement(By.id("DepartureCity")).clear();
    driver.findElement(By.id("DepartureCity")).sendKeys("Florida");
    Thread.sleep(1000);
    driver.findElement(By.id("TripStartDate")).clear();
    driver.findElement(By.id("TripStartDate")).sendKeys("12-24-2018");
    Thread.sleep(1000);
    driver.findElement(By.id("TripEndDate")).clear();
    driver.findElement(By.id("TripEndDate")).sendKeys("01-01-2019");
    Thread.sleep(1000);
    driver.findElement(By.id("MaxTravellers")).clear();
    driver.findElement(By.id("MaxTravellers")).sendKeys("10");
    Thread.sleep(1000);
    driver.findElement(By.id("TravelMode")).click();
    new Select(driver.findElement(By.id("TravelMode"))).selectByVisibleText("Car");
    driver.findElement(By.id("TravelMode")).click();
    Thread.sleep(1000);
    driver.findElement(By.id("Cost")).click();
    driver.findElement(By.id("Cost")).clear();
    driver.findElement(By.id("Cost")).sendKeys("600.00");
    Thread.sleep(1000);
    driver.findElement(By.id("TripDescription")).clear();
    driver.findElement(By.id("TripDescription")).sendKeys("Avoid the warm weather, come north for the holidays!");
    Thread.sleep(2000);
    ((JavascriptExecutor)driver).executeScript("arguments[0].scrollIntoView();", driver.findElement(By.id("Cost")));
    Thread.sleep(1000);
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Upload a custom picture:'])[1]/following::input[2]")).click();
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
